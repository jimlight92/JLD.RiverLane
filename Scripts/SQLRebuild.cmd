@echo off

sqlcmd -S sql10.hostinguk.net -d RiverLane -U JLD -P JLD123JLD456 -i %~dp0%FullBuild\00_DropDatabase.sql
@echo Database dropped

sqlcmd -S sql10.hostinguk.net -d RiverLane -U JLD -P JLD123JLD456 -i %~dp0%\FullBuild\01_Tables.sql
@echo Tables created

sqlcmd -S sql10.hostinguk.net -d RiverLane -U JLD -P JLD123JLD456 -i %~dp0%\FullBuild\02_Primarys.sql
@echo Primary keys added

sqlcmd -S sql10.hostinguk.net -d RiverLane -U JLD -P JLD123JLD456 -i %~dp0%\FullBuild\03_Foreigns.sql
@echo Foreign keys added

sqlcmd -S sql10.hostinguk.net -d RiverLane -U JLD -P JLD123JLD456 -i %~dp0%\FullBuild\04_Inserts.sql
@echo Inserts completed