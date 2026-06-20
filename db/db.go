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
}
