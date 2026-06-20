package handlers

import (
	"encoding/json"
	"net/http"
	"oMapBackend/models"
)

func GetUserHandler(writer http.ResponseWriter, request *http.Request) {
	user := models.User{
		ID:       1,
		Username: "Carson",
		Email:    "carsoni@alumni.iastate.edu",
	}

	writer.Header().Set("Content-Type", "application/json")
	json.NewEncoder(writer).Encode(user)
}
