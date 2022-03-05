# ReadingList-Data
Backup repo containing my [ReadingList](https://github.com/andmos/ReadingList.git) data.

## Analysis

Count author occurrences:
```sh
cat done.json | jq '.[].authors[0]' | sort | uniq -c |sort -nr
```
Get all titles by author:
```sh
cat backlog.json | jq '.[] | select (.authors[0]=="Richard Feynman").title'
```
