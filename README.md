# Endpointy

### Dodanie autora
#### Request
- URL: `/author/add`
- Payload:

| Pole | Typ | Komentarz |
|------|-----|----------|
| `firstName` | `string` | Wymagane |
| `lastName` | `string` | Wymagane |

### Pobranie autora
#### Request
- URL: `/author/:id`

#### Response
- Payload:

| Pole | Typ |
|------|-----|
| `_id` | `ObjectId` |
| `firstName` | `string` |
| `lastName` | `string` |

### Aktualizacja autora
#### Request
- URL: `/author/update/:id`
- Payload:

| Pole | Typ |
|------|-----|
| `firstName` | `string` |
| `lastName` | `string` |

### Usunięcie autora
#### Request
- URL: `/author/:id`
