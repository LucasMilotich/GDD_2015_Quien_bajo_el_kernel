
DECLARE @SqlStatement VARCHAR(MAX)
SELECT @SqlStatement = 
    COALESCE(@SqlStatement, '') + 'DROP TABLE [QUIEN_BAJO_EL_KERNEL].' + QUOTENAME(TABLE_NAME) + ';' + CHAR(13)
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_SCHEMA = 'QUIEN_BAJO_EL_KERNEL'

PRINT @SqlStatement


select   'ALTER TABLE QUIEN_BAJO_EL_KERNEL.' + t.name + ' drop constraint ' + 
OBJECT_NAME(d.constraint_object_id)  + ';' + CHAR(13)
from sys.tables t 
    join sys.foreign_key_columns d on d.parent_object_id = t.object_id 
    inner join sys.schemas s on t.schema_id = s.schema_id
where s.name = 'QUIEN_BAJO_EL_KERNEL'
ORDER BY t.name;
