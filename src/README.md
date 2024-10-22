# CarfyOrcamento

## Descrição
CarfyOrcamento é um microserviço API desenvolvido em C# com .NET 8, utilizando o banco de dados PostgreSQL. A arquitetura do projeto é em camadas, facilitando a manutenção e escalabilidade.

## Funcionalidades
- **Orçamento e Cotação**: Gerenciamento de orçamentos e cotações para peças automotivas.
- **Produtos**: Inclusão de produtos no orçamento.
- **Frete**: Cálculo e inclusão de frete.
- **Desconto**: Aplicação de descontos nos orçamentos.
- **Cotação com Fornecedores**: Possibilidade de cotar com diversos fornecedores.

## Tecnologias Utilizadas
- **Linguagem**: C#
- **Framework**: .NET 8
- **Banco de Dados**: PostgreSQL
- **Containerização**: Docker

## Estrutura do Projeto
O projeto segue uma arquitetura em camadas, dividida da seguinte forma:
- **Camada de Apresentação**: Contém os controladores da API.
- **Camada de Aplicação**: Contém os casos de uso e lógica de aplicação.
- **Camada de Domínio**: Contém as entidades e regras de negócio.
- **Camada de Infraestrutura**: Contém a configuração do banco de dados e repositórios.

## Configuração do Ambiente de Desenvolvimento
Para configurar o ambiente de desenvolvimento, siga os passos abaixo:

1. **Clone o repositório**:
    ```sh
    git clone https://github.com/michaelfaleiro/carfy-orcamento.git
    cd carfy-orcamento
    ```

2. **Configuração do Docker**:
    - Certifique-se de ter o Docker e Docker Compose instalados.
    - Utilize o comando abaixo para subir a aplicação e o banco de dados:
        ```sh
        docker-compose up --build
        ```

## Em Desenvolvimento
Este projeto ainda está em desenvolvimento. Novas funcionalidades e melhorias estão sendo adicionadas continuamente.

## Contribuição
Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests.

## Licença
Este projeto está licenciado sob a licença MIT. Veja o arquivo `LICENSE` para mais detalhes.