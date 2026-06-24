namespace SQL_EYES
{
    public static class SqlQueries
    {
        public const string ActiveConnections = @"
IF OBJECT_ID(N'tempdb..#activeprocesses', N'U') IS NOT NULL DROP TABLE #activeprocesses

SELECT 
    s.session_id AS [Session ID],
    s.login_name AS [Login Name],
    s.host_name AS [Host Name],
    ISNULL(s.program_name, '') AS [Program Name],
    s.status AS [Status],
    DB_NAME(ISNULL(r.database_id, s.database_id)) AS [Database],
    r.command AS [Command],
    r.cpu_time AS [CPU Time],
    r.total_elapsed_time AS [Total Elapsed Time],
    r.logical_reads AS [Logical Reads],
    r.reads AS [Reads],
    r.writes AS [Writes],
    r.blocking_session_id AS [Blocking Session],
    SUBSTRING(st.text, (r.statement_start_offset/2)+1,   
        ((CASE r.statement_end_offset  
            WHEN -1 THEN DATALENGTH(st.text)  
            ELSE r.statement_end_offset  
        END - r.statement_start_offset)/2) + 1) AS [Query Text]
FROM sys.dm_exec_sessions s
LEFT OUTER JOIN sys.dm_exec_connections c ON s.session_id = c.session_id
LEFT OUTER JOIN sys.dm_exec_requests r ON s.session_id = r.session_id
OUTER APPLY sys.dm_exec_sql_text(r.sql_handle) AS st 
WHERE s.session_Id > 50 
AND s.session_Id NOT IN (@@SPID)
ORDER BY s.session_id";

        public const string TempDBInfo = @"
SELECT 
    name AS [File Name],
    physical_name AS [Physical Path],
    size * 8.0 / 1024 AS [Size (MB)],
    (size * 8.0 / 1024) - (FILEPROPERTY(name, 'SpaceUsed') * 8.0 / 1024) AS [Free Space (MB)],
    FILEPROPERTY(name, 'SpaceUsed') * 8.0 / 1024 AS [Used Space (MB)]
FROM tempdb.sys.database_files";

        public const string TempDBTables = @"
SELECT 
    tb.name AS [Temporary Table Name],
    stt.row_count AS [Row Count], 
    stt.used_page_count * 8 AS [Used Space (KB)], 
    stt.reserved_page_count * 8 AS [Reserved Space (KB)] 
FROM tempdb.sys.partitions AS prt 
INNER JOIN tempdb.sys.dm_db_partition_stats AS stt ON prt.partition_id = stt.partition_id 
INNER JOIN tempdb.sys.tables AS tb ON stt.object_id = tb.object_id 
ORDER BY [Reserved Space (KB)] DESC";

        public const string TempDBSessions = @"
SELECT  
    SS.session_id AS [Session ID],
    SS.database_id AS [Database ID],
    CAST(SS.user_objects_alloc_page_count / 128 AS DECIMAL(15, 2)) AS [Total User Objects (MB)],
    CAST((SS.user_objects_alloc_page_count - SS.user_objects_dealloc_page_count) / 128 AS DECIMAL(15, 2)) AS [Net User Objects (MB)],
    CAST(SS.internal_objects_alloc_page_count / 128 AS DECIMAL(15, 2)) AS [Total Internal Objects (MB)],
    CAST((SS.internal_objects_alloc_page_count - SS.internal_objects_dealloc_page_count) / 128 AS DECIMAL(15, 2)) AS [Net Internal Objects (MB)],
    CAST((SS.user_objects_alloc_page_count + internal_objects_alloc_page_count) / 128 AS DECIMAL(15, 2)) AS [Total Allocation (MB)],
    CAST((SS.user_objects_alloc_page_count + SS.internal_objects_alloc_page_count - SS.internal_objects_dealloc_page_count - SS.user_objects_dealloc_page_count) / 128 AS DECIMAL(15, 2)) AS [Net Allocation (MB)],
    T.text AS [Query Text]
FROM sys.dm_db_session_space_usage SS
LEFT JOIN sys.dm_exec_connections CN ON CN.session_id = SS.session_id
OUTER APPLY sys.dm_exec_sql_text(CN.most_recent_sql_handle) T
ORDER BY [Net Allocation (MB)] DESC";

        public const string ShrinkTempDB = @"
USE tempdb
CHECKPOINT
DBCC FREESYSTEMCACHE ('ALL')
DBCC SHRINKFILE (tempdev, 8)
DBCC SHRINKFILE (templog, 1)";

        public const string BufferPoolByDatabase = @"
SELECT 
    DB_NAME([database_id]) AS [Database Name],
    COUNT(*) AS [Pages in Buffer],
    COUNT(*) / 128 AS [Buffer Size (MB)]
FROM sys.dm_os_buffer_descriptors
WHERE [database_id] > 4
GROUP BY [database_id]
ORDER BY [Pages in Buffer] DESC";

        public const string BufferPoolByTable = @"
SELECT 
    obj.name AS [Object Name], 
    o.type_desc AS [Object Type],
    i.name AS [Index Name], 
    i.type_desc AS [Index Type],
    COUNT(*) AS [Cached Pages Count],
    COUNT(*)/128 AS [Cached Pages (MB)]
FROM sys.dm_os_buffer_descriptors AS bd
INNER JOIN (
    SELECT object_name(object_id) AS name, object_id, index_id, allocation_unit_id
    FROM sys.allocation_units AS au
    INNER JOIN sys.partitions AS p ON au.container_id = p.hobt_id
    AND (au.type = 1 OR au.type = 3)
    UNION ALL
    SELECT object_name(object_id) AS name, object_id, index_id, allocation_unit_id
    FROM sys.allocation_units AS au
    INNER JOIN sys.partitions AS p ON au.container_id = p.partition_id
    AND au.type = 2
) AS obj ON bd.allocation_unit_id = obj.allocation_unit_id
INNER JOIN sys.indexes i ON obj.[object_id] = i.[object_id]
INNER JOIN sys.objects o ON obj.[object_id] = o.[object_id]
WHERE database_id = DB_ID()
GROUP BY obj.name, i.type_desc, o.type_desc, i.name
ORDER BY [Cached Pages (MB)] DESC";

        public const string AllDatabaseSizes = @"
IF OBJECT_ID('tempdb.dbo.#space') IS NOT NULL DROP TABLE #space

CREATE TABLE #space (
    database_id INT PRIMARY KEY,
    data_used_size DECIMAL(18,2),
    log_used_size DECIMAL(18,2)
)

DECLARE @SQL NVARCHAR(MAX)

SELECT @SQL = STUFF((
    SELECT '
    USE [' + d.name + ']
    INSERT INTO #space (database_id, data_used_size, log_used_size)
    SELECT DB_ID(),
        SUM(CASE WHEN [type] = 0 THEN space_used END),
        SUM(CASE WHEN [type] = 1 THEN space_used END)
    FROM (
        SELECT s.[type], space_used = SUM(FILEPROPERTY(s.name, ''SpaceUsed'') * 8. / 1024)
        FROM sys.database_files s
        GROUP BY s.[type]
    ) t;'
    FROM sys.databases d
    WHERE d.[state] = 0
    FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '')

EXEC sys.sp_executesql @SQL

SELECT
    d.name AS [Database Name],
    d.state_desc AS [State],
    d.recovery_model_desc AS [Recovery Model],
    t.total_size AS [Total Size (MB)],
    t.data_size AS [Data Size (MB)],
    s.data_used_size AS [Data Used (MB)],
    t.log_size AS [Log Size (MB)],
    s.log_used_size AS [Log Used (MB)]
FROM (
    SELECT
        database_id,
        log_size = CAST(SUM(CASE WHEN [type] = 1 THEN size END) * 8. / 1024 AS DECIMAL(18,2)),
        data_size = CAST(SUM(CASE WHEN [type] = 0 THEN size END) * 8. / 1024 AS DECIMAL(18,2)),
        total_size = CAST(SUM(size) * 8. / 1024 AS DECIMAL(18,2))
    FROM sys.master_files
    GROUP BY database_id
) t
INNER JOIN sys.databases d ON d.database_id = t.database_id
LEFT JOIN #space s ON d.database_id = s.database_id
ORDER BY t.total_size DESC

DROP TABLE #space";

        public const string TableSizes = @"
SELECT 
    t.NAME AS [Table Name],
    s.Name AS [Schema Name],
    p.rows AS [Row Count],
    CAST(ROUND(((SUM(a.total_pages) * 8) / 1024.00), 2) AS NUMERIC(36, 2)) AS [Total Space (MB)],
    CAST(ROUND(((SUM(a.used_pages) * 8) / 1024.00), 2) AS NUMERIC(36, 2)) AS [Used Space (MB)],
    CAST(ROUND(((SUM(a.total_pages) - SUM(a.used_pages)) * 8) / 1024.00, 2) AS NUMERIC(36, 2)) AS [Unused Space (MB)]
FROM sys.tables t
INNER JOIN sys.indexes i ON t.OBJECT_ID = i.object_id
INNER JOIN sys.partitions p ON i.object_id = p.OBJECT_ID AND i.index_id = p.index_id
INNER JOIN sys.allocation_units a ON p.partition_id = a.container_id
LEFT OUTER JOIN sys.schemas s ON t.schema_id = s.schema_id
WHERE t.NAME NOT LIKE 'dt%' 
    AND t.is_ms_shipped = 0
    AND i.OBJECT_ID > 255 
GROUP BY t.Name, s.Name, p.Rows
ORDER BY [Total Space (MB)] DESC";

        public const string ClearBuffer = @"
CHECKPOINT
DBCC DROPCLEANBUFFERS
DBCC FREEPROCCACHE";

        public const string ConnectedUsers = @"
SELECT 
    login_name AS [Login Name],
    host_name AS [Host Name],
    program_name AS [Program Name],
    DB_NAME(database_id) AS [Database],
    COUNT(session_id) AS [Session Count]
FROM sys.dm_exec_sessions
WHERE session_id > 50
GROUP BY login_name, host_name, program_name, database_id
ORDER BY [Session Count] DESC";

        public static string GetIndexMaintenanceScript(bool reportOnly = true, int fragmentationThreshold = 5, 
            string scanMode = "LIMITED", int fillFactor = 90, string sortInTempDB = "ON")
        {
            return $@"
SET NOCOUNT ON;

DECLARE @verboseMode BIT = 1
DECLARE @reportOnly BIT = {(reportOnly ? "1" : "0")}
DECLARE @fragmentationThreshold VARCHAR(10) = '{fragmentationThreshold}'
DECLARE @indexStatisticsScanningMode VARCHAR(20) = '{scanMode}'
DECLARE @indexFillFactor VARCHAR(10) = '{fillFactor}'
DECLARE @sortInTempdb VARCHAR(10) = '{sortInTempDB}'

IF OBJECT_ID('tempdb..#tmpFragmentedIndexes') IS NOT NULL DROP TABLE #tmpFragmentedIndexes

CREATE TABLE #tmpFragmentedIndexes (
    dbName NVARCHAR(128),
    tableName NVARCHAR(128),
    schemaName NVARCHAR(128),
    indexName NVARCHAR(128),
    databaseID INT,
    objectID INT,
    indexID INT,
    AvgFragmentationPercentage FLOAT,
    reorganizationOrRebuildCommand NVARCHAR(MAX)
)

INSERT INTO #tmpFragmentedIndexes
SELECT
    DB_NAME() as [dbName], 
    tbl.name as [tableName],
    SCHEMA_NAME(tbl.schema_id) as schemaName, 
    idx.Name as [indexName], 
    DB_ID() as [databaseID], 
    pst.object_id as [objectID], 
    pst.index_id as [indexID], 
    pst.avg_fragmentation_in_percent as [AvgFragmentationPercentage],
    CASE 
        WHEN pst.avg_fragmentation_in_percent > 30 THEN 
            'ALTER INDEX ['+idx.Name+'] ON ['+DB_NAME()+'].['+SCHEMA_NAME(tbl.schema_id)+'].['+tbl.name+'] REBUILD WITH (FILLFACTOR = '+@indexFillFactor+', SORT_IN_TEMPDB = '+@sortInTempdb+', STATISTICS_NORECOMPUTE = OFF);'
        WHEN pst.avg_fragmentation_in_percent > 5 AND pst.avg_fragmentation_in_percent <= 30 THEN 
            'ALTER INDEX ['+idx.Name+'] ON ['+DB_NAME()+'].['+SCHEMA_NAME(tbl.schema_id)+'].['+tbl.name+'] REORGANIZE;'
        ELSE NULL
    END
FROM sys.dm_db_index_physical_stats(DB_ID(), NULL, NULL, NULL, @indexStatisticsScanningMode) as pst
INNER JOIN sys.tables as tbl ON pst.object_id = tbl.object_id
INNER JOIN sys.indexes idx ON pst.object_id = idx.object_id AND pst.index_id = idx.index_id
WHERE pst.index_id != 0  
    AND pst.alloc_unit_type_desc IN (N'IN_ROW_DATA', N'ROW_OVERFLOW_DATA')
    AND pst.avg_fragmentation_in_percent >= {fragmentationThreshold}

SELECT  
    dbName AS [Database],
    tableName AS [Table],
    schemaName AS [Schema],
    indexName AS [Index Name],            
    AvgFragmentationPercentage AS [Fragmentation %],
    reorganizationOrRebuildCommand AS [Recommended Action]
FROM #tmpFragmentedIndexes
ORDER BY AvgFragmentationPercentage DESC

DROP TABLE #tmpFragmentedIndexes";
        }
    }
}
