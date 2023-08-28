# Code First

Nach dem wir die Entities erstellt haben, können die Tabellen in der Datenbank erstellt werden.

dafür sind zwei Schritte nötig:

1. Migration aus Entities erstell duch folgender Befehl in der "Package Management Console"

```
Add-migration CreateInitial -o Data/Migrations
```
so werden die Migrations Scripte im Verzeichnis "Data/Migrations" gespeichert.

2. Script auf Datenbank ausführen

```
update-database
```
