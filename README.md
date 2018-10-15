# Book Seller
BooksSeller is an application that allows the user to list books and edit their information.

The purpose of this exercise is to complete an Angular application as well as the Web API and integrate both.
The Angular application contains two views, one to list a set of books and another to edit a selected book. 
The list shall present all books stored and the editor shall update the information of a book.

The books information shall be retrieved and stored by the Web API. Books can be stored anywhere 
(including in memory) as long as the storage is also delivered with the exercise and the data is 
available to be loaded.

## Some requirements for the Web API:
* Use DI for dependency injection.
* Unit tests shall be created for BooksProvider and BooksController.

## Some requirements for the client application:
* Only one view shall be displayed at a time hence if the user wants to see the list of books then the editor shall be invisible and vice-versa.
* Error messages must be shown only if the values in the model are invalid.
* Save should be enabled only if the form is valid.
* When cancelling an edition, the form must restore the previous model state.

Good Luck
