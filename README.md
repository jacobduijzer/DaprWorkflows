# DaprWorkflows

## Running the Workflows

```
cd src/SickReportingWorkflow
dapr run --config ../../dapr/dapr.yaml --components-path ../../dapr/components --app-id workflow --dapr-grpc-port 4001 --dapr-http-port 3500 -- dotnet run
```

## Running the GraphQL Api

```
cd src/Api
dotnet run
```

Open the url and add /graphql, see mutation query below.

## Mutation

```
mutation AddNewSickReport($sr: SickReportInput!) {
  addNewSickReport (sickReport: $sr) {
    workflowReferenceId
  }
}
```

## Input

```json
{
  "sr": {
    "firstName": "Jacob",
    "lastName": "Duijzer",
    "birthDate": "1979-08-27",
    "sickSince": "2023-01-01",
    "citizenServiceNumber": "5678",
    "gender": "MALE"
  }
}

