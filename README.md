# ELibrary
Elibrary is app designed for managing books and employees in Library.
App is ready to run after cloning from github. It uses SQLite so ther is no need to configure database connection.

## Database overview:
There are four entities:
- Book -contain information about book like title, description, authors
- Author -contains information about book author
- Borrowing -contains details about borrowed book like date of borrowing, ane returning deadline
- Librarian -contains information about library workers

## Functionalities:
App provides acces to peforming operations based on user roles. To login use following credentials:
- for user: login: user , password: 1Userpassword!
- for administrator: login: admin, password: 1Adminpassword!
  
User has acces to operations:
- add new author
- list all authors
- get list of books assigned to author
- update author
- assign book to author
- add new book
- list all books
- edit book
- remove book
- borrow book
- return book
- list books over return date

Admin has all user permissions and additionaly can manage Librarians by actions:
- add new librarian
- update librarian details
- remove librarian
- get information about librarian
