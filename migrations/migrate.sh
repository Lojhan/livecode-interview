sleep 5s

find . -name "*.sql" -exec /opt/mssql-tools/bin/sqlcmd \
    -S $MSSQL_DATABASE \
    -U $MSSQL_USER \
    -P $MSSQL_SA_PASSWORD \
    -d master \
    -i {} \;
