# Endpointy

## Dodanie autora
### Request
- URL: `/author/add`
- Metoda: `POST`
- Payload:

| Pole | Typ | Komentarz |
|------|-----|----------|
| `firstName` | `string` | Wymagane |
| `lastName` | `string` | Wymagane |

## Pobranie autorów
### Request
- URL: `/author/list`
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
- URL: `/author/:id`
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
- URL: `/author/update/:id`
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
| `isbn` | `type` | |
| `pages` | `int` | |
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
| `author` | `Category[]` |
| `pages` | `int` |
| `isbn` | `string` |
| `type` | `string` |
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
| `author` | `Category[]` |
| `pages` | `int` |
| `isbn` | `string` |
| `type` | `string` |
| `publicationDate` | `date` |

## Usunięcie książki
### Request
- URL: `/book/:id`
- Metoda: `DELETE`
