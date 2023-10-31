
# Restaurante-API

## About this Project:

The idea of this project is build an Api rest for a restaurant

## Why?

I've been using .Net 7 with SQL Server for a while, so I wanted to put all my knowledge into practice, building a project for something I like to work on, a store/restaurant.

As this project is part of my personal portfolio, I would be very happy to receive feedback on the project and perhaps some ways to improve it.

## The Project:

An API for restaurants with authentication performed by jwt, has a complete crud for meals, orders, menus and users.

#### Meals: You can add a new meal, delete meals, update meals, search meal by her id and get a list with all meals.

#### Menu: You can add a new Menu, delete menus, add meals to the menu, remove meals from menu and get a list with all menus and meals or filtering by his id.

#### Order: You can add a new Order, delete Orders, update Orders, add a new meal to an order, search order by her id or get a list with all meals.

#### User: You can Delete an user, update user and get a list of users name.

#### Authenticate: It is possible to register a new user on the system and authenticate receiving the token.

The API has loggers, is fully documented within the application, DTO's and automapper were also used.
The application was made using .net 7 with sql server.

## How to Run:
In order to run the project you will need to have Visual Studio installed
With the Project open, select the RestauranteAPI solution and do the following:
* Clean Solution
* Build Solution
* Restore NuGetPackages

Go to Package Manager console and execute the command:
* Update-Database

## Api Documentation

### User

#### Register a new User

```http
  POST /login/Register
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `nome` | `string` | **Obrigatório**. Person Name |
| `nomeUsuario` | `string` | **Obrigatório**. User |
| `senha` | `string` | **Obrigatório**. User password |

#### Authenticate User

```http
  POST /login/Login
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `nomeUsuario`      | `string` | **Obrigatório**. Username |
| `senha`      | `string` | **Obrigatório**. User password |


Returns a jwt.

### Meal

#### Get all meals list

```http
  GET /Refeicao
```

Returns a list of meals

#### Get a meal by id

```http
  GET /Refeicao/get-by-meal-id/{id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Id`      | `id` | **Obrigatório**. Meal id |


Returns a meal.

#### Add a new meal

```http
  POST /Refeicao
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `nome`      | `string` | **Obrigatório**. Meal name |
| `preco`      | `decimal` | **Obrigatório**. Meal price |
| `descricao`      | `string` | **Obrigatório**. Meal description |


#### Update Meal

```http
  PUT /Refeicao
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Id`      | `id` | **Obrigatório**. Meal id |
| `nome`      | `string` | **Obrigatório**. Meal name |
| `preco`      | `decimal` | **Obrigatório**. Meal price |
| `descricao`      | `string` | **Obrigatório**. Meal description |

#### Delete Meal

```http
  Delete /Refeicao
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Id`      | `id` | **Obrigatório**. Meal id |

### Menu

#### Get all menus list

```http
  GET /Cardapio
```

Returns a list of menus

#### Get a menu by id

```http
  GET /Cardapio/get-by-id/{id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Id`      | `id` | **Obrigatório**. Menu id |


Returns a menu.

#### Add a new menu

```http
  POST /Cardapio
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `nomeCardapio`      | `string` | **Obrigatório**. Menu name |

#### Update Menu

```http
  PUT /Cardapio
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Id`      | `id` | **Obrigatório**. Menu id |
| `nomeCardapio`      | `string` | **Obrigatório**. Menu name |

#### Delete Menu

```http
  Delete /Cardapio
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Id`      | `id` | **Obrigatório**. Menu id |

#### Add a meal to a menu

```http
  POST /Cardapio/add-meal-to-menu/
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `cardapioId`      | `id` | **Obrigatório**. Menu Id |
| `refeicaoId`      | `string` | **Obrigatório**. Meal Id |

#### Delete a meal of a menu

```http
  Delete /Cardapio/delete-meal-menu/
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `cardapioId`      | `id` | **Obrigatório**. Menu Id |
| `refeicaoId`      | `string` | **Obrigatório**. Meal Id |

### Order

#### Get all orders list

```http
  GET /Order
```

Returns a list of orders

#### Get an order by id

```http
  GET /Order/get-order-by-id/{id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Id`      | `id` | **Obrigatório**. Order id |


Returns an order.

#### Add a new order

```http
  POST /Order
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `usuarioId`      | `string` | **Obrigatório**. User Id |

#### Add a meal to an order

```http
  POST /Order/add-meal-to-order/
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `pedidoId`      | `id` | **Obrigatório**. Order Id |
| `refeicaoId`      | `string` | **Obrigatório**. Meal Id |

#### Delete a meal of an order

```http
  Delete /Order/delete-meal-order/
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `pedidoId`      | `id` | **Obrigatório**. Order Id |
| `refeicaoId`      | `string` | **Obrigatório**. Meal Id |

#### Delete Order

```http
  Delete /Order
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Id`      | `id` | **Obrigatório**. Order id |


### User

#### Get all users list

```http
  GET /User
```

Returns a list of users

#### Get an user by id

```http
  GET /User/get-by-id/{id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Id`      | `id` | **Obrigatório**. User id |


Returns an user.

#### Delete User

```http
  Delete /User
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `Id`      | `id` | **Obrigatório**. User id |


## Contact Me

-  [Linkedin](https://www.linkedin.com/in/jo%C3%A3o-paulo-marques-43ba10242/)
-  [Email](mailto:jpmarques2000@hotmail.com)

