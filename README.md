# Resumo  
- Este projeto, disponível no GitHub (https://github.com/gfmaurila/projeto.base.ddd.netcore7), foi desenvolvido com base nos princípios do Domain-Driven Design (DDD) e utiliza a versão 7 do .NET Core.
- A estrutura básica do projeto segue a arquitetura DDD, fornecendo uma organização clara e modular. O objetivo é facilitar o desenvolvimento de sistemas complexos, separando as responsabilidades em diferentes camadas.
- Além disso, o projeto também inclui um Docker Compose com uma seleção de imagens para auxiliar na implementação gradual do ambiente de desenvolvimento. As seguintes imagens estão disponíveis:


- Mongoserver: uma instância do MongoDB, um banco de dados NoSQL orientado a documentos.
- MySQL: um sistema de gerenciamento de banco de dados relacional.
- Redis: um banco de dados em memória para armazenamento em cache e gerenciamento de dados-chave.
- Postgres: outro sistema de gerenciamento de banco de dados relacional, com recursos avançados.
- SQL Server: um sistema de gerenciamento de banco de dados relacional da Microsoft.
- RabbitMQ: um sistema de mensageria que permite a comunicação entre os componentes do sistema de forma assíncrona.
- Kafdrop: uma interface de usuário para visualizar e gerenciar tópicos e mensagens no Apache Kafka.
- Kafka: uma plataforma de streaming distribuído que permite a troca de mensagens em tempo real.
- Essas imagens fornecem uma base sólida para a implementação de diferentes aspectos do projeto, permitindo a escolha adequada dos componentes de acordo com as necessidades específicas.

- No geral, o projeto base é uma excelente referência para iniciar o desenvolvimento de sistemas utilizando o DDD e o .NET Core 7, além de fornecer um ambiente de desenvolvimento facilitado pelo Docker Compose com várias opções de banco de dados e sistemas de mensageria.


![image](https://github.com/gfmaurila/projeto.base.ddd.netcore7/assets/5544035/241fb1b1-3d86-4bf1-b531-a2c5a502a366)


![image](https://github.com/gfmaurila/projeto.base.ddd.netcore7/assets/5544035/27b06b21-e96f-4c61-92b2-dcbd96225b44)


# Projeto 
- http://localhost:5072/index.html
- http://localhost:5072/swagger/index.html

# Docker
- http://localhost:5072/swagger/index.html

# KafKa
- http://localhost:9000

# RabbitMQ
- http://localhost:15672

# SQLServer
- Server=sqlserver;Integrated Security=true;Initial Catalog=CrudDDDDotNetNet7;User Id=sa;Password=@C23l10a1985;Trusted_Connection=false;MultipleActiveResultSets=true;Encrypt=True;TrustServerCertificate=True;


# Health Checks
- https://localhost:7102/monitor#/healthchecks
- https://libraries.io/nuget/AspNetCore.HealthChecks.Rabbitmq

# Docker 
- http://localhost:5072/monitor#/healthchecks
![image](https://github.com/gfmaurila/projeto.base.ddd.netcore7/assets/5544035/5c417116-dcc3-40f1-820f-3e27ae488c6d)

![image](https://github.com/gfmaurila/projeto.base.ddd.netcore7/assets/5544035/3ee69336-c2e7-40d9-99e1-25f63e3e80a1)

# Swagger Doc
- GET

![image](https://github.com/gfmaurila/projeto.base.ddd.netcore7/assets/5544035/85a0c388-16ed-4d3b-8575-f9db4e50a7e9)

- GET BY ID

![image](https://github.com/gfmaurila/projeto.base.ddd.netcore7/assets/5544035/540bf0c8-07a1-419d-b5b2-8f20d98958ce)

![image](https://github.com/gfmaurila/projeto.base.ddd.netcore7/assets/5544035/cd2df303-be0b-4ff0-b3b2-7c2f7d240234)

- POST - Create

![image](https://github.com/gfmaurila/projeto.base.ddd.netcore7/assets/5544035/1c1f73b3-a52d-4348-b2ab-80d50f32799a)

![image](https://github.com/gfmaurila/projeto.base.ddd.netcore7/assets/5544035/77bd4e62-84d1-44fd-9a1b-eb23cd03db78)

- PUT - Update

![image](https://github.com/gfmaurila/projeto.base.ddd.netcore7/assets/5544035/6707a6b0-e917-4ce8-919d-8300fd0e0e08)

![image](https://github.com/gfmaurila/projeto.base.ddd.netcore7/assets/5544035/9e841fc7-3308-4dea-8e56-1403fe047fd4)

- DELETE

![image](https://github.com/gfmaurila/projeto.base.ddd.netcore7/assets/5544035/bd67931a-c707-4fce-8647-be11b9c59beb)

![image](https://github.com/gfmaurila/projeto.base.ddd.netcore7/assets/5544035/8a4aabe0-8e13-40e8-ae54-ba86f9ea04b7)


## Autor

- Guilherme Figueiras Maurila
 
[![Linkedin Badge](https://img.shields.io/badge/-Guilherme_Figueiras_Maurila-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/guilherme-maurila-58250026/)](https://www.linkedin.com/in/guilherme-maurila-58250026/)
[![Gmail Badge](https://img.shields.io/badge/-gfmaurila@gmail.com-c14438?style=flat-square&logo=Gmail&logoColor=white&link=mailto:gfmaurila@gmail.com)](mailto:gfmaurila@gmail.com)
