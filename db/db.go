package db

import (
	"database/sql"
	"log"

	_ "github.com/mattn/go-sqlite3"
)

var DB *sql.DB

func Connect() {

	//Open DB Connection
	database, err := sql.Open("sqlite3", "./app.db")
	if err != nil {
		log.Fatal(err)
	}

	//Ping DB
	err = database.Ping()
	if err != nil {
		log.Fatal(err)
	}

	DB = database

	createTables()
}

func createTables() {
	query := `
	CREATE TABLE IF NOT EXISTS users(
		id INTEGER PRIMARY KEY AUTOINCREMENT,
		username TEXT NOT NULL,
		email TEXT NOT NULL
	);
	`

	_, err := DB.Exec(query)
	if err != nil {
		log.Fatal(err)
	}

	seedQuery := `
	INSERT INTO users (username, email)
	SELECT 'Carson', 'carsoni@alumni.iastate.edu'
	WHERE NOT EXISTS (
		SELECT 1 FROM users WHERE email = 'carsoni@alumni.iastate.edu'
	);
	`

	_, err = DB.Exec(seedQuery)
	if err != nil {
		log.Fatal(err)
	}
}
