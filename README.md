# RosariumBackEnd

## Descrição
O **RosariumBackEnd** é um projeto que consome a API 'https://liturgiadiaria.site', fornecendo informações sobre a liturgia do dia. Atualmente, o projeto utiliza um Schedule para buscar os dados da API uma vez ao dia e armazená-los no banco de dados. Posteriormente, a API consome esses dados do banco e os disponibiliza.

## Funcionalidades Atuais
- Schedule para busca diária na API 'https://liturgiadiaria.site'
- O Schedule faz o Armazenamento dos dados da liturgia no banco de dados
- API para fornecer os dados da liturgia

## Funcionalidades Futuras
- Implementação de um Schedule para buscar os dados na API diariamente e enviá-los para uma fila do RabbitMQ
- Desenvolvimento de um consumidor do RabbitMQ para processar os dados da fila e enviá-los para a API, a fim de serem gravados
- Integração com o Docker para facilitar a execução e orquestração do projeto
- Utilização pelo aplicativo RosariumApp (em andamento) para consumir os dados da API

## Contato
Para mais informações ou colaborações, entre em contato com [Diego Moreira Ribeiro](https://www.linkedin.com/in/diego-moreira-ribeiro-dev/).

---

*Nota: Este projeto está em constante desenvolvimento. Qualquer contribuição é bem-vinda.*
