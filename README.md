# Endpointy
 
 ## Dodanie biblioteki
### Request
- URL: `/library/add`
- Metoda: `POST`
- Payload:

| Pole | Typ | Komentarz |
|------|-----|----------|
| `name` | `string` | Wymagane |
| `email` | `string` | |
| `city` | `string` | |
| `street` | `string` | |
| `houseNumber` | `string` | |
| `phone` | `string` | |

## Pobranie bibliotek
### Request
- URL: `/library/list`
- Meroga: `GET`
- Query:

| Nazwa | Type |
|-------|------|
| `page` | `int` |
| `limit` | `int` |

## Response
| Pole | Type |
|------|------|
| `page` | `int` |
| `pages` | `int` |
| `data` | `Library[]` |

## Pobranie biblioteki
### Request
- URL: `/library/:id`
- Metoda: `GET`

### Response
- Payload:

| Pole | Typ |
|------|-----|
| `id` | `ObjectId` |
| `name` | `string` |
| `email` | `string` |
| `city` | `string` |
| `street` | `string` |
| `houseNumber` | `string` |
| `phone` | `string` |

## Aktualizacja biblioteki
### Request
- URL: `/library/update/:id`
- Metoda: `PUT`
- Payload:

| Pole | Typ |
|------|-----|
| `name` | `string` |
| `email` | `string` |
| `city` | `string` |
| `street` | `string` |
| `houseNumber` | `string` |
| `phone` | `string` |

## Usunięcie bibloteki
### Request
- URL: `/library/:id`
- Metoda: `DELETE`


## Dodanie autora
### Request
- URL: `/library/add`
- Metoda: `POST`
- Payload:

| Pole | Typ | Komentarz |
|------|-----|----------|
| `firstName` | `string` | Wymagane |
| `lastName` | `string` | Wymagane |

## Pobranie autorów
### Request
- URL: `/library/list`
- Meroga: `GET`
- Query:

| Nazwa | Type |
|-------|------|
| `page` | `int` |
| `limit` | `int` |

## Response
| Pole | Type |
|------|------|
| `page` | `int` |
| `pages` | `int` |
| `data` | `Author[]` |

## Pobranie autora
### Request
- URL: `/library/:id`
- Metoda: `GET`

### Response
- Payload:

| Pole | Typ |
|------|-----|
| `id` | `ObjectId` |
| `firstName` | `string` |
| `lastName` | `string` |

## Aktualizacja autora
### Request
- URL: `/library/update/:id`
- Metoda: `PUT`
- Payload:

| Pole | Typ |
|------|-----|
| `firstName` | `string` |
| `lastName` | `string` |

## Usunięcie autora
### Request
- URL: `/author/:id`
- Metoda: `DELETE`

## Dodanie kategorii
### Request
- URL: `/category/add`
- Metoda: `POST`
- Payload:

| Pole | Typ | Komentarz |
|------|-----|----------|
| `name` | `string` | Wymagane |

## Pobranie kategorii
### Request
- URL: `/category/list`
- Meroga: `GET`
- Query:

| Nazwa | Type |
|-------|------|
| `page` | `int` |
| `limit` | `int` |

## Response
| Pole | Type |
|------|------|
| `page` | `int` |
| `pages` | `int` |
| `data` | `Category[]` |

## Pobranie kategorii
### Request
- URL: `/category/:id`
- Metoda: `GET`

### Response
- Payload:

| Pole | Typ |
|------|-----|
| `id` | `ObjectId` |
| `name` | `string` |

## Aktualizacja kategorii
### Request
- URL: `/category/update/:id`
- Metoda: `PUT`
- Payload:

| Pole | Typ |
|------|-----|
| `name` | `string` |

## Usunięcie kategorii
### Request
- URL: `/category/:id`
- Metoda: `DELETE`


## Dodanie książki
### Request
- URL: `/book/add`
- Metoda: `POST`
- Payload:

| Pole | Typ | Komentarz |
|------|-----|----------|
| `title` | `string` | Wymagane |
| `description` | `string` | Wymagane |
| `author` | `ObjectId` | Wymagane |
| `category` | `Category[]` | |
| `isbn` | `string` | |
| `type` | `string` | |
| `pages` | `int` | |
| `bookCover` | `string[]` | |
| `publicationDate` | `date` | |

## Pobranie książek
### Request
- URL: `/book/list`
- Meroga: `GET`
- Query:

| Nazwa | Type |
|-------|------|
| `page` | `int` |
| `limit` | `int` |

## Response
| Pole | Type |
|------|------|
| `page` | `int` |
| `pages` | `int` |
| `data` | `Book[]` |


## Pobranie książek autora
### Request
- URL: `/book/list/author/:id`
- Meroga: `GET`
- Query:

| Nazwa | Type |
|-------|------|
| `page` | `int` |
| `limit` | `int` |

## Response
| Pole | Type |
|------|------|
| `page` | `int` |
| `pages` | `int` |
| `data` | `Book[]` |

## Pobranie książki
### Request
- URL: `/book/:id`
- Metoda: `GET`

### Response
- Payload:

| Pole | Typ |
|------|-----|
| `id` | `ObjectId` |
| `title` | `string` |
| `description` | `string` |
| `author` | `ObjectId` |
| `category` | `Category[]` |
| `pages` | `int` |
| `isbn` | `string` |
| `type` | `string` |
| `bookCover` | `string[]` |
| `publicationDate` | `date` |

## Aktualizacja książki
### Request
- URL: `/book/update/:id`
- Metoda: `PUT`
- Payload:

| Pole | Typ |
|------|-----|
| `title` | `string` |
| `description` | `string` |
| `author` | `ObjectId` |
| `category` | `Category[]` |
| `pages` | `int` |
| `isbn` | `string` |
| `type` | `string` |
| `bookCover` | `string[]` |
| `publicationDate` | `date` |

## Usunięcie książki
### Request
- URL: `/book/:id`
- Metoda: `DELETE`
