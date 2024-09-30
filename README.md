# data-grabber solution

1. Compile list of KEY=URL
2. Get page by key, save locally
3. Parce page, extract info
4. Save infos into single file
5. Import file into Excel

# page-retriever

Takes care of #2

2. Get page by key, save locally

## Operation

Runs on a folder structure:

Root
- exe
- In
  - list.txt
- Out
  - Date
    - key.html

# data-grabber

Takes care of #3 and #4

3. Parce page, extract info
4. Save infos into single file
