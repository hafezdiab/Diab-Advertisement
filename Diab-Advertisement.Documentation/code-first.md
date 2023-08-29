# Code First

Nach dem wir die Entities erstellt haben, können die Tabellen in der Datenbank erstellt werden.

dafür sind zwei Schritte nötig:

1. Migration aus Entities erstell duch folgender Befehl in der "Package Management Console"

```
add-migration CreateInitial -p Diab-Advertisement.Infrastructure -s Diab-Advertisement.Api -o Data/Migrations
```
so werden die Migrations Scripte im Verzeichnis "Data/Migrations" gespeichert.

2. Script auf Datenbank ausführen

```
update-database
```

Um Migration zu entfernen, muss vorher die Datenbank gelöscht werden.

Datanbank löschen

```
drop-database -p Diab-Advertisement.Infrastructure -s Diab-Advertisement.Api
```

Migration entfernen

```
remove-migration -p Diab-Advertisement.Infrastructure -s Diab-Advertisement.Api
```
