# VVSecurity

**VVSecurity** é um projeto de API desenvolvido em **C# e ASP.NET Core (.NET 10)**, com foco na geração de chaves de segurança criptograficamente seguras. A proposta é oferecer uma base organizada para a emissão de tokens e chaves aleatórias utilizados por sistemas e integrações.

## Objetivo

Gerar chaves secretas com alta entropia, sem depender de identificadores previsíveis ou de algoritmos de hash de senhas. A geração utiliza o gerador de números aleatórios criptograficamente seguro disponibilizado pelo .NET.

## Geração de chaves

O gerador utiliza `RandomNumberGenerator.GetBytes(32)` para produzir **32 bytes aleatórios (256 bits)**. Em seguida, os bytes são convertidos para **Base64URL sem padding**, resultando em uma string de **43 caracteres**.

```csharp
using System.Security.Cryptography;

public static string GenerateSecurityKey()
{
    var key = RandomNumberGenerator.GetBytes(32);

    return Convert.ToBase64String(key)
        .TrimEnd('=')
        .Replace('+', '-')
        .Replace('/', '_');
}
```

### Por que CSPRNG?

- **Imprevisibilidade:** os bytes são gerados por uma fonte apropriada para uso criptográfico.
- **Alta entropia:** uma chave uniformemente aleatória de 256 bits dispõe de `2^256` valores possíveis.
- **Simplicidade:** a geração não requer um GUID, salt ou derivação com Argon2id.
- **Eficiência:** evita o custo computacional de um algoritmo destinado principalmente à proteção de senhas.

> **Importante:** Base64URL é uma **codificação**, não uma forma de criptografia. O segredo da chave está na aleatoriedade dos bytes originais, e não no formato textual.

### Exemplo de formato

Uma resposta de API que disponibilize a chave pode seguir este formato:

```json
{
  "securityToken": "<chave-aleatoria-em-base64url>"
}
```

O exemplo demonstra o **formato do payload** e não estabelece uma rota de API: os endpoints ainda devem ser conferidos na implementação correspondente.

## Tecnologias

- **C#** — linguagem de desenvolvimento.
- **.NET 10** — framework de execução.
- **ASP.NET Core Web API** — infraestrutura HTTP.
- **System.Security.Cryptography** — geração de bytes criptograficamente aleatórios.
- **Swagger** — documentação de API habilitada no ambiente de desenvolvimento.

## Estrutura do projeto

A solução está organizada em quatro projetos:

```text
VVSecurity/
├── src/
│   └── Backend/
│       ├── VVSecurity.Api/
│       ├── VVSecurity.Application/
│       ├── VVSecurity.Domain/
│       └── VVSecurity.Infrastructure/
├── VVSecurity.slnx
└── README.md
```

| Camada | Responsabilidade |
| --- | --- |
| `VVSecurity.Api` | Entrada HTTP, configuração da aplicação e exposição dos endpoints. |
| `VVSecurity.Application` | Orquestração dos casos de uso e regras da aplicação. |
| `VVSecurity.Domain` | Contratos, entidades e regras centrais do domínio. |
| `VVSecurity.Infrastructure` | Implementações técnicas dos contratos, como o gerador de chaves. |

A separação busca manter as responsabilidades bem definidas e facilitar manutenção, testes e evolução.

## Executando localmente

### Pré-requisitos

- [.NET SDK 10](https://dotnet.microsoft.com/download/dotnet/10.0)
- Git

### Instalação

Clone o repositório:

```bash
git clone https://github.com/Foqsz/VVSecurity.git
cd VVSecurity
```

Restaure as dependências e compile a solução:

```bash
dotnet restore VVSecurity.slnx
dotnet build VVSecurity.slnx
```

Inicie a API:

```bash
dotnet run --project src/Backend/VVSecurity.Api/VVSecurity.Api.csproj
```

A aplicação exibirá no terminal os endereços HTTP/HTTPS configurados para o ambiente local.

## Boas práticas de segurança

- Gere sempre as chaves com um gerador criptograficamente seguro, como `RandomNumberGenerator`.
- Transmita chaves secretas somente por canais protegidos por HTTPS.
- Evite registrar chaves em logs ou incluí-las em repositórios e exemplos reais.
- Se a chave funcionar como **token de autenticação**, considere armazenar somente seu hash (por exemplo, SHA-256) e comparar o hash da chave recebida.
- Se a chave for utilizada para **criptografia ou HMAC**, preserve o segredo de forma segura, pois o hash não substitui a chave original para esses usos.
- Defina validade, revogação, rotação e limitação de tentativas conforme o contexto de uso.

## Autor

Desenvolvido por [Foqsz](https://github.com/Foqsz).

## Licença

Este projeto está disponibilizado sob a **Licença MIT**. Consulte o arquivo [LICENSE.txt](LICENSE.txt).
