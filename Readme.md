## Setup Jaeger tracing in API

## Distributed Tracing, Open Tracing, and Jaeger

### Distributed Tracing is the capability of a tracing solution that you can use to track a request across multiple services. The tracing solutions use one or more correlation IDs to collate the request traces and store the traces, which are structured log events across different services, in a central database.

### Jaeger is an open-source tracing system for microservices, and it supports the Open Tracing standard. It was initially built and open-sourced by Uber Technologies and is now a CNCF graduated project. Some of the high-level use cases of Jaeger are the following:

    * 1. Performance and latency optimization
    * 2. Distributed transaction monitoring
    * 3. Service dependency analysis
    * 4. Distributed context propagation
    * 5. Root cause analysis

### Docker compose file

```bash
version: "3"

services:
  jaeger: 
    image: jaegertracing/all-in-one:1
    hostname: jaeger
    container_name: jaeger
    ports:
      - "6831:6831/udp"
      - "16686:16686"
  postgres:
    image: "postgres:13-alpine"
    hostname: "postgres"
    container_name: postgres
    ports:
      - "5432:5432"
```

#### docker continer run
```bash

docker compose -f jaegertracing.yml up

```