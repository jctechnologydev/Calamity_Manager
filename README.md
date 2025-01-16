# Gestão de calamidade numa situação de crise pública
## Motivação
Pretende-se que sejam desenvolvidas soluções em C# para problemas reais de
complexidade moderada. Serão identificadas as principais entidades (classes)
envolvidas, as estruturas para suportar os dados e implementados os principais
processos capazes de suportar soluções para esses problemas.
Pretende-se ainda contribuir para a boa redação de relatórios que descrevam o
trabalho desenvolvido, a boa documentação de código fonte com a geração da
API, e a gestão e planeamento de trabalho via ferramentas apropriadas (Git,
GitHub, Trello, ou outras).

## Objectivos gerais
• Consolidar conceitos basilares do Paradigma Orientado a Objectos;

• Analisar problemas reais;

• Desenvolver capacidades de programação em C#;

• Potenciar a experiência no desenvolvimento de software;

• Assimilar o conteúdo da Unidade Curricular.

## Objetivos Concretos

• Saber identificar e implementar classes e objetos num problema real;

• Saber produzir código com qualidade, bem documentado, de acordo com
a norma CLS;

• Saber gerar a API com a documentação do código que produziu (Doxigen
ou outro);

• Saber aplicar os pilares da POO: Herança, Encapsulamento, Abstração e
Polimorfismo;

• Saber estruturar devidamente uma solução em bibliotecas de classes;

• Saber estruturar uma solução por camadas, seguindo padrões como NTier
ou MVC;

• Conseguir definir uma estratégia de persistência de dados;

• Saber analisar o código que produziu;

• Saber executar testes simples sobre o código produzido;

• Saber explorar das vantagens que o C# oferece.


## Outros Objetivos
• Saber utilizar ferramentas de gestão de versões de código.
• Saber utilizar ferramentas de gestão de projetos.
5 Regras do "Jogo"

As datas de cada fase e as metas a atingir em cada uma, são:
• Fase 1 (30-04-2021)

– Diagrama de classes

– Implementação essencial das classes

– Definição das estruturas de dados a utilizar

– Estruturação do Projeto em camadas

– Relatório do trabalho desenvolvido até à data

• Fase 2 (28-05-2021)

– Implementação final das classes e serviços

– Aplicação demonstradora dos serviços implementados

– Relatório final do trabalho realizado

## Problema a explorar


• Sistema que permita gerir pessoas infetadas numa situação de crise de
saúde pública: registar novos casos, contabilizar casos, consultar casos
por região, sexo, idades, outros. Etc.



##  Qualidade do Relatório
• Estrutura, Clareza e Expressividade

• Capacidade de síntese e correção da escrita

## Qualidade da solução desenvolvida

• Qualidade do código produzido: estrutura da solução, nome de ficheiros,

uso de bibliotecas, Norma CLS;

• Organização e Implementação das Classes;

• Qualidade dos algoritmos aplicados;

• Estruturas de dados exploradas;

• Tratamento adequado de excepções;

• Persistência de dados com recurso a ficheiros ou outros;

• Exploração de outras valências: Lambda Functions; LINQ; MVC; WPF;

• Qualidade da API produzida;

• Cumprimento dos prazos e fases estipuladas.



<p align="center">  
  <a href="https://github.com/VanessaSwerts/github-search/commits/master">
    <img alt="GitHub last commit" src="https://img.shields.io/github/last-commit/VanessaSwerts/github-search">
  </a>    
   <img alt="License" src="https://img.shields.io/badge/license-MIT-brightgreen">  
   <img alt="GitHub Workflow Status" src="https://img.shields.io/github/workflow/status/VanessaSwerts/github-search/testes-jest">	
</p>

<h4 align="center"> 
	🚧 GitHub Search - Concluído 🚧
</h4>

<p align="center">
 <a href="#-sobre-o-projeto">Sobre</a> •
 <a href="#-funcionalidades">Funcionalidades</a> •
 <a href="#-como-executar-o-projeto">Como executar</a> • 
 <a href="#-autor">Autor</a> • 
 <a href="#user-content--licença">Licença</a>
</p>


## 💻 Sobre o projeto

Consolidar conceitos basilares do Paradigma Orientado a Objectos;

• Analisar problemas reais;

• Desenvolver capacidades de programação em C#;

• Potenciar a experiência no desenvolvimento de software;

• Assimilar o conteúdo da Unidade Curricular.

## Objetivos Concretos

• Saber identificar e implementar classes e objetos num problema real;

• Saber produzir código com qualidade, bem documentado, de acordo com
a norma CLS;

• Saber gerar a API com a documentação do código que produziu (Doxigen
ou outro);

• Saber aplicar os pilares da POO: Herança, Encapsulamento, Abstração e
Polimorfismo;

• Saber estruturar devidamente uma solução em bibliotecas de classes;

• Saber estruturar uma solução por camadas, seguindo padrões como NTier
ou MVC;

• Conseguir definir uma estratégia de persistência de dados;

• Saber analisar o código que produziu;

• Saber executar testes simples sobre o código produzido;

• Saber explorar das vantagens que o C# oferece.


Acesse o site: [GitHub Search](https://github-search-vs.herokuapp.com)

---

## ⚙️ Funcionalidades
 
- [x] Gerir uma situação de calamidade

---

## 🚀 Como executar o projeto

### Pré-requisitos


#### 🧭  Execute this project


   ```bash
    # Clone this repository
    $ git clone https://github.com/VanessaSwerts/github-search.git

    # O servidor inciará na porta:3000 - acesse http://localhost:3000 .
   ```

---

## 📁 Estrutura de arquivos

Atualizado 08/04/2021

```bash
github-search
├─ .gitignore
├─ LICENSE
├─ package.json
├─ public
│  ├─ favicon.ico
│  ├─ index.html
│  ├─ logo192.png
│  ├─ logo512.png
│  ├─ manifest.json
│  └─ robots.txt
├─ README.md
├─ src
│  ├─ App.css
│  ├─ App.js
│  ├─ components
│  │  ├─ Button
│  │  │  ├─ Button.css
│  │  │  └─ Button.js
│  │  ├─ Card
│  │  │  ├─ Card.css
│  │  │  └─ Card.js
│  │  ├─ Error
│  │  │  ├─ Error.css
│  │  │  └─ Error.js
│  │  ├─ Footer
│  │  │  ├─ Footer.css
│  │  │  └─ Footer.js
│  │  ├─ Header
│  │  │  ├─ Header.css
│  │  │  └─ Header.js
│  │  ├─ index.js
│  │  └─ Loading
│  │     ├─ Loading.css
│  │     └─ Loading.js
│  ├─ index.js
│  ├─ pages
│  │  ├─ Home
│  │  │  ├─ Home.css
│  │  │  └─ Home.js
│  │  └─ index.js
│  ├─ services
│  │  └─ api.js
│  ├─ setupTests.js
│  └─ __tests__
│     ├─ snapshots
│     │  ├─ components
│     │  │  ├─ Button.test.js
│     │  │  ├─ Card.test.js
│     │  │  ├─ Error.test.js
│     │  │  ├─ Footer.test.js
│     │  │  ├─ Header.test.js
│     │  │  ├─ Loading.test.js
│     │  │  └─ __snapshots__
│     │  │     ├─ Button.test.js.snap
│     │  │     ├─ Card.test.js.snap
│     │  │     ├─ Error.test.js.snap
│     │  │     ├─ Footer.test.js.snap
│     │  │     ├─ Header.test.js.snap
│     │  │     └─ Loading.test.js.snap
│     │  └─ pages
│     │     ├─ Home.test.js
│     │     └─ __snapshots__
│     │        └─ Home.test.js.snap
│     └─ unit
│        └─ pages
│           └─ Home.test.js
└─ yarn.lock

```

## 🦸 Autor

<table>
  <tr>   
    <td align="center"><a href="https://github.com/vanessaSwerts/"><img style="border-radius: 50%;" src="imagehere" width="100px;" alt=""/><br /><sub><b>Joel Jonassi</b></sub></a></td>  
  </tr>
</table>

---

## 📝 Licença

Este projeto esta sobe a licença [MIT](./LICENSE).

