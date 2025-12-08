# Book Library

A simple command-line application for managing a book library.

## Features

- Add books to the library
- List all books
- Search books by title or author
- Check out books to borrowers
- Return books
- Remove books from the library

## Usage

```bash
# Add a book
dotnet run -- add "The Great Gatsby" "F. Scott Fitzgerald" "978-0743273565"

# List all books
dotnet run -- list

# Search for books
dotnet run -- search title "Gatsby"
dotnet run -- search author "Fitzgerald"

# Check out a book (you'll need the book ID from list/search)
dotnet run -- checkout <book-id> "John Doe"

# Return a book
dotnet run -- return <book-id>

# Remove a book
dotnet run -- remove <book-id>
```

## Building

```bash
dotnet build
```

## Running

```bash
dotnet run -- <command> [arguments]
```
