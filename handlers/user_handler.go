package handlers

import (
	"encoding/json"
	"net/http"
	"oMapBackend/db"
	"oMapBackend/models"
)

func GetUserHandler(writer http.ResponseWriter, request *http.Request) {

	writer.Header().Set("Content-Type", "application/json")

	var user models.User

	row := db.DB.QueryRow(`
	SELECT id, username, email
	FROM users
	WHERE id = ?
	`, 1)

	err := row.Scan(&user.ID, &user.Username, &user.Email)
	if err != nil {
		http.Error(writer, "User not found", http.StatusNotFound)
		return
	}

	json.NewEncoder(writer).Encode(user)
}
