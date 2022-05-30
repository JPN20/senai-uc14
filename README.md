<h2 align="center">
    SENAI - SP    
</h2>
<h3 align="center">
    ExoAPI - Gerenciamento de projetos
</h3>

<p align="center">
    <a href="https://github.com/ortegavan/senai-uc14/commits/">
        <img alt="GitHub last commit" src="https://img.shields.io/github/last-commit/ortegavan/senai-uc14?style=flat-square">
    </a>
    <a href="https://github.com/prettier">
        <img alt="code style: prettier" src="https://img.shields.io/badge/code_style-prettier-ff69b4.svg?style=flat-square">
    </a>
</p>

![](https://github.com/ortegavan/senai-uc14/blob/54662e19f30ea5129bf3921be9adb9d6ceb2e916/banner.jpg)

A ExoAPI fornece endpoints para o cadastro de projetos e o cadastro de usuários. Cada um de seus métodos está listado a seguir.

## Endpoints e seus métodos

### Login

Permite a um usuário se autenticar na API.

#### Request

> POST: /api/login

```json
{
	"email": "teste@teste.com",
	"senha": "12345"
}
```

#### Response

```json
{
	"token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...."
}
```

---

### Listar projetos

Busca todos os projetos cadastrados no banco. Requer autenticação.

#### Request

> GET: /api/projetos

#### Response

```json
[
	{
		"id": 2,
		"titulo": "Projeto 2",
		"inicio": "2021-10-31T00:00:00",
		"status": 1,
		"tecnologias": ".net"
	},
	{
		"id": 3,
		"titulo": "Projeto 3",
		"inicio": "2021-10-31T13:30:00",
		"status": 2,
		"tecnologias": ".net, c#, api, angular"
	}
]
```

---

### Buscar projeto por id

Localiza um projeto específico pelo seu id. Requer autenticação.

#### Request

> GET: /api/projetos/{id}

#### Response

```json
{
	"id": 2,
	"titulo": "Projeto 2",
	"inicio": "2021-10-31T00:00:00",
	"status": 1,
	"tecnologias": ".net"
}
```

---

### Cadastrar projeto

Insere um novo projeto no banco de dados. Requer autenticação.

#### Request

> POST: /api/projetos

```json
{
	"titulo": "Projeto 4",
	"inicio": "2021-10-31T13:30:00",
	"status": 1,
	"tecnologias": ".net"
}
```

#### Response

```json
{
	"id": 4,
	"titulo": "Projeto 4",
	"inicio": "2021-10-31T13:30:00",
	"status": 1,
	"tecnologias": ".net"
}
```

---

### Alterar projeto

Permite alterar os dados de um projeto existente. Requer autenticação.

#### Request

> PUT: /api/projetos/{id}

```json
{
	"titulo": "Projeto 4",
	"inicio": "2021-10-31T13:30:00",
	"status": 2,
	"tecnologias": ".net"
}
```

#### Response

```json
{
	"id": 4,
	"titulo": "Projeto 4",
	"inicio": "2021-10-31T13:30:00",
	"status": 2,
	"tecnologias": ".net"
}
```

---

### Excluir projeto

Exclui um projeto do banco de dados. Requer autenticação.

#### Request

> DELETE: /api/projetos/{id}

#### Response

```json
"Projeto removido"
```

---

### Listar usuários

Busca todos os usuários cadastrados no banco de dados. Requer autenticação.

#### Request

> GET: /api/usuarios

#### Response

```json
[
	{
		"id": 1,
		"nome": "Teste 1",
		"email": "teste1@teste.com",
		"senha": "",
		"perfil": 1
	},
	{
		"id": 2,
		"nome": "Teste 2",
		"email": "teste2@teste.com",
		"senha": "",
		"perfil": 2
	}
]
```

---

### Buscar usuário

Busca um usuário específico pelo seu id. Requer autenticação.

#### Request

> GET: /api/usuarios/{id}

#### Response

```json
{
	"id": 1,
	"nome": "Teste 1",
	"email": "teste1@teste.com",
	"senha": "",
	"perfil": 1
}
```

---

### Cadastrar usuário

Insere um novo usuário na base de dados.

#### Request

> POST: /api/usuarios

```json
{
	"nome": "Teste 5",
	"email": "teste5@teste.com",
	"senha": "12345"
}
```

#### Response

```json
{
	"id": 5,
	"nome": "Teste 5",
	"email": "teste5@teste.com",
	"senha": "",
	"perfil": 2
}
```

---

### Alterar usuário

Altera os dados de um usuário existente. Requer autenticação.

#### Request

> PUT: /api/usuarios/{id}

```json
{
	"nome": "Teste 5",
	"email": "teste5@teste.com",
	"senha": "12345"
}
```

#### Response

```json
{
	"id": 5,
	"nome": "Teste 5",
	"email": "teste5@teste.com",
	"senha": "",
	"perfil": 2
}
```

---

### Excluir usuário

Exclui um usuário pelo seu id. Requer autenticação + perfil de administrador.

#### Request

> DELETE: /api/usuarios/{id}

#### Response

```json
"Usuário removido"
```

## Tecnologias utilizadas

Web API escrita em C# na plataforma .NET 6.0.

## Organização do projeto

O projeto está organizado conforme descrição a seguir:

**Pasta Contexts**: contém a classe de acesso e mapeamento do banco de dados

**Pasta Repositories**: contém as classes de manipulação de dados de cada uma das entidades

**Pasta Models**: contém as classes de modelo que representam cada uma das entidades

**Pasta Enumeradores**: contém as especificações de perfil do usuário (administrador, usuário comum) e os possíveis status de um projeto (não iniciado, em desenvolvimento, cancelado, pausado, em homologação, finalizado)

**Pasta Controllers**: contém os controladores que implementam e expõem os endpoints e métodos da API

**Pasta Tools**: contém a classe Password.cs que oferece método para hashear as senhas antes de transitar com elas entre camadas

## Pré-requisitos para edição

-   .NET SDK 6.0
-   Visual Studio 2022 ou Visual Studio for Mac
-   Git e acesso ao GitHub

## Pré-requisitos para execução

-   .NET Runtime 6.0

## Execução da aplicação

### No Visual Studio 2022

Clique com o botão direito do mouse na solução e selecione a opção "Run solution"

## Colaboradores

Vanessa Ortega
