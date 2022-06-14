# ReadingList-Data
Backup repo containing my [ReadingList](https://github.com/andmos/ReadingList.git) data.

## Analysis

Count author occurrences:
```sh
curl -s https://app.amosti.net/reading/api/donelist | jq '.[].authors[]' | sort | uniq -c | sort -nr
```
Get all titles by author:
```sh
cat done.json | jq '.[] | select (.authors[] == "Richard Feynman").title'
```
