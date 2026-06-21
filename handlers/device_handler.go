package handlers

import (
	"encoding/json"
	"net/http"
	is "oMapBackend/internal_structures"
	"oMapBackend/models"
)

func GetDeviceHandler(writer http.ResponseWriter, request *http.Request) {
	device := models.Device{
		ID:       1,
		Name:     "carsons-laptop",
		Type:     "Laptop",
		Position: is.Vector2{X: 1, Y: 1},
		Color:    "#dc2626",
	}

	writer.Header().Set("Content-Type", "application/json")
	json.NewEncoder(writer).Encode(device)
}
