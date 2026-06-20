package main

import (
	"encoding/json"
	"log"
	"net/http"
	"oMapBackend/db"
	"oMapBackend/handlers"
)

type HealthResponse struct {
	Status string `json:"status"`
}

func healthHandler(writer http.ResponseWriter, r *http.Request) {
	writer.Header().Set("Content-Type", "application/json")

	response := HealthResponse{
		Status: "ok",
	}

	json.NewEncoder(writer).Encode(response)
}

func main() {
	db.Connect()

	http.HandleFunc("/health", healthHandler)
	http.HandleFunc("/user", handlers.GetUserHandler)

	log.Println("Server running on http://localhost:8080")
	log.Fatal(http.ListenAndServe(":8080", nil))
}
