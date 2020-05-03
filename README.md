## Run API##
```
<root-project>$ cd ImportCsv.Api**
./ImportCsv.Api>$ docker-compose up
```
## Config GrayLog ##
  ### Graylog login##
    - User: admin
    - Password: admin
  ### Config inputs ###
    1. Acess http://localhost:9000/system/inputs
    2. Select option "GELF UDP"
    3. Click "Launch New Input"
    4. Check "Global"
    5. Set Title "Gelf"
    6. Click "Save"
  ### Config outputs ###
    1. Acess http://localhost:9000/system/outputs
    2. Select Output type "GELF Output"
    3. Click "Launch New Output"
    4. Set Title "Gelf"
    5. Destination host "0.0.0.0"
    6. Select Protocol "UDP"
    7. Click "Save"
    
## Run Tests##
```
<root-project>$ dotnet test**
```
