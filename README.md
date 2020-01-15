# Endpointy

## Dodanie autora
### Request
- URL: `/author/add`
- Payload:

| Pole | Typ | Komentarz |
|------|-----|----------|
| `firstName` | `string` | Wymagane |
| `lastName` | `string` | Wymagane |

## Pobranie autora
### Request
- URL: `/author/:id`

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
- Payload:

| Pole | Typ |
|------|-----|
| `firstName` | `string` |
| `lastName` | `string` |

## Usunięcie autora
### Request
- URL: `/author/:id`


## Dodanie książki
### Request
- URL: `/book/add`
- Payload:

| Pole | Typ | Komentarz |
|------|-----|----------|
| `title` | `string` | Wymagane |
| `description` | `string` | Wymagane |
| `author` | `ObjectId` | Wymagane |
| `pages` | `number` | |
| `publicationDate` | `date` | |

## Pobranie książki
### Request
- URL: `/book/:id`

### Response
- Payload:

| Pole | Typ |
|------|-----|
| `id` | `ObjectId` |
| `title` | `string` |
| `description` | `string` |
| `author` | `ObjectId` |
| `pages` | `number` |
| `publicationDate` | `date` |

## Aktualizacja książki
### Request
- URL: `/book/update/:id`
- Payload:

| Pole | Typ |
|------|-----|
| `title` | `string` |
| `description` | `string` |
| `author` | `ObjectId` |
| `pages` | `number` |
| `publicationDate` | `date` |

## Usunięcie książki
### Request
- URL: `/book/:id`
