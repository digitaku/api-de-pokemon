# Api de Pokemon
api rest em dotnet core utilizando efcore como ORM, sqlite como banco e automapper para mapeamento de entidades.
## Como Executar ??
- Necessita a dotnet CLI ou Visual Studio instalado
- Necessita o dotnet-ef `dotnet tool install --global dotnet-ef` instalado ou Visual Studio
- `dotnet ef database update` cria o banco de dados
- `dotnet run` roda a aplicação
- aplicação estará rodando em http://locahost:5000/api/pokemon
## Rotas da aplicação
### Rotas de GET
- htttp://localhost:5000/api/pokemon
- htttp://localhost:5000/api/pokemon/Pikachu
- htttp://localhost:5000/api/types
- htttp://localhost:5000/api/types/nome
- htttp://localhost:5000/api/abilities
- htttp://localhost:5000/api/abilities/nome
### Rotas de POST
- htttp://localhost:5000/api/pokemon - presisa de um body com o pokemon
- htttp://localhost:5000/api/types - presisa de um body com o tipo
- htttp://localhost:5000/api/abilities - presisa de um body com a ability
### Rotas de PUT
- htttp://localhost:5000/api/pokemon - presisa de um body com o pokemon
- htttp://localhost:5000/api/types - presisa de um body com o tipo
- htttp://localhost:5000/api/abilities - presisa de um body com a ability
### Rotas de DELETE
- htttp://localhost:5000/api/pokemon/Pikachu
- htttp://localhost:5000/api/types/nome
- htttp://localhost:5000/api/abilities/nome
## Exemplo de Corpo para Requisição
### Pokemon
{
	"name": "Pikachu",
	"alias": "Mouse Pokémon",
	"imageUrl": "http://site.pikachu.png",
	"abilities": [
		"name": "Electric"
	],
	"types": [
		{
			"name": "Eletric"
		}
	]
}
### Tipo
{
	"name": "Electric",
	"color": "Yellow"
}
### Ability
{
  "name": "Static",
  "effectDescription": "When a Pokémon with this Ability is hit by a move that makes contact, there is a 30% chance that the attacking Pokémon will become paralyzed. This can affect Ground-type Pokémon.",
  "isHidden": false
}
