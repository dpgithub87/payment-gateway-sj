# payment-gateway

## Purpose / Description / Scope

This service exposes public endpoints to create/retrieve payments by a merchant. 

## Overview

### payment-gateway

The service hosts the following endpoints,

```
-- Payments --
POST /v1/payments
GET  /v1/payments/{id}

```
POST v1/payments

[![](https://mermaid.ink/img/pako:eNqdkUFLAzEQhf9KmKuV4jWHQqVQPEgXU2-5DMlog5vZmJ1UltL_3ui6qBQLOqeZyfsej8wBXOcJNPT0WogdrQI-Z4yWG8wSXEjIou4pu11tfm4bHCKxrFHoDYdlCpZVrUl8vVhcnUm0ajZmq-b7m3ka3_qROlP-gq-JKdd5AtSd_5uBkS5_0SsSDO2lDLfILybE0mIFp_j_y_6Y_PfkRlDKJYvpJ7V6ICmZVaY-ddwTzCBSjhh8vdzh3cGC7CiSBV1bT09YWrFg-VilWKQzAzvQkgvNoHzE-Dz0uDyeALU4uN4?type=png)](https://mermaid.live/edit#pako:eNqdkUFLAzEQhf9KmKuV4jWHQqVQPEgXU2-5DMlog5vZmJ1UltL_3ui6qBQLOqeZyfsej8wBXOcJNPT0WogdrQI-Z4yWG8wSXEjIou4pu11tfm4bHCKxrFHoDYdlCpZVrUl8vVhcnUm0ajZmq-b7m3ka3_qROlP-gq-JKdd5AtSd_5uBkS5_0SsSDO2lDLfILybE0mIFp_j_y_6Y_PfkRlDKJYvpJ7V6ICmZVaY-ddwTzCBSjhh8vdzh3cGC7CiSBV1bT09YWrFg-VilWKQzAzvQkgvNoHzE-Dz0uDyeALU4uN4)

GET v1/payments

[![](https://mermaid.ink/img/pako:eNp9kEGLAjEMhf9KydWRwWsPwoIiexBE99hLmD7XwrQztqnLMMx_3-roSXZzCknel-SN1HQWpCnhmhEabBx_R_YmqBJ7xObCQZbr9eLAg0eQHQt-ePjonVa77Zeqb6u6n1upHp_Zp51mwJvoD9IREh1ueAnUBsKuTf9QXrc9xDkGFZH6LiRQRR7Rs7PlrfFOMCQXeBjSJbU4c27FkAlTGeUs3WkIDWmJGRXl3pY1TxdIn7lNpQrrpIv72aqHY9Mv6Dlt_g?type=png)](https://mermaid.live/edit#pako:eNp9kEGLAjEMhf9KydWRwWsPwoIiexBE99hLmD7XwrQztqnLMMx_3-roSXZzCknel-SN1HQWpCnhmhEabBx_R_YmqBJ7xObCQZbr9eLAg0eQHQt-ePjonVa77Zeqb6u6n1upHp_Zp51mwJvoD9IREh1ueAnUBsKuTf9QXrc9xDkGFZH6LiRQRR7Rs7PlrfFOMCQXeBjSJbU4c27FkAlTGeUs3WkIDWmJGRXl3pY1TxdIn7lNpQrrpIv72aqHY9Mv6Dlt_g)





## How to build

```
dotnet build
```

## How to run in docker

```
docker build -t payment-gateway -f Dockerfile .  
docker run -it --rm -p 6000:80 -e "ASPNETCORE_ENVIRONMENT=Development" payment-gateway 

```

## How to test

### Unit Tests

```
cd test/PaymentGateway.UnitTests
dotnet test
```

### Integration Tests

```
cd test/PaymentGateway.Integrationtests
dotnet test
```

## Get in touch


## Checklists

