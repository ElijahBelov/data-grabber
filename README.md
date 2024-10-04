# data-grabber solution

1. Compile list of KEY=URL
2. Get page by key, save locally
3. Parce page, extract info
4. Save infos into single file
5. Import file into Excel

# page-retriever

Takes care of #2

2. Get page by key, save locally

## Folder structure

Root
- exe
- process.log
- `In`
  - list.txt
- `Out`
  - `Date`
    - key.html

`List.txt` is a CSV file with KEY - URL pairs

## Operation

1. Looks in /`In`/`list.txt` and for each line downloads a page
2. Saves page locally as /`Out`/`date of run`/`KEY`.html
3. Produces a `process.log` file with processed KEYs and failures if any

# data-grabber

Takes care of #3 and #4

3. Parce page, extract info
4. Save infos into single file

## Folder structure

Root
- exe
- process.log
- `In`
  - key.html's
- `Pending`
  - key.html
- `Processed`
  - `Date`
    - key.html's
- `Failed`
  - key.html's
- `Out`
  - data.csv

## Operation

1. Looks in /`In` folder for any `key.html` and for each
2. Moves file into /`Pending` folder
3. Parces HTML extracting info
4. Upon success moves file from /`Pending` into /`Processed` folder
5. On error moves file from /`Pending` into /`Failed` folder
6. Save extracted info in /`Out`/`data.csv`
7. Produces a `process.log` file with processed KEYs and failures if any

