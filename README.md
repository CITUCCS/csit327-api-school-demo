# School API
### Repositories
These are data access classes. Should only work with Models and focused on dealing with DATA. No business logic.

### Services
These classes serve as middle man between Controllers and Repositories. This is where business logic resides. 

### Controllers
These are classes where you design your URLs and endpoints. Should not care about Data Access, should not have any business logic.

### Models
These are your business domain models.

### DTOs
These are lightweight classes used only to transfer data.