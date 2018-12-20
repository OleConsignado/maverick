# Maverick
[![Build Status](https://travis-ci.org/OleConsignado/maverick.svg?branch=master)](https://travis-ci.org/OleConsignado/maverick)

**Maverick** é um modelo de arquitetura de software para projetos .NET Core baseado na Arquitetura Hexagonal (Alistair Cockburn).

## Criando um projeto baseado no Maverick

A forma mais simples de criar um projeto baseado no **Maverick** é por meio do mecanismo de templates do .NET Core.

Para instalar (ou atualizar) o template do **Maverick** na sua máquina (o pacote do template está hospedado no [NuGet.org](https://www.nuget.org/packages/Maverick)), simplesmente execute:

```
$ dotnet new -i maverick
```

Para criar um projeto usando o template **Maverick**, execute:

```
$ dotnet new maverick --name=MeuProjeto
```

Caso deseje desinstalar o template **Maverick**, execute:

```
$ dotnet new -u maverick
```

## Colaborando com o Maverick

*Issues* e *Pull Requests* são bem vindos.

