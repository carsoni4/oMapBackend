package handlers

import (
	"encoding/json"
	"net/http"
	"oMapBackend/db"
	"oMapBackend/models"
)

func GetDeviceHandler(writer http.ResponseWriter, request *http.Request) {
	writer.Header().Set("Content-Type", "application/json")

	var device models.Device

	row := db.DB.QueryRow(`
	SELECT id, name, type, position, color
	FROM devices 
	WHERE id = ?
	`, 1)

	err := row.Scan(&device.ID, &device.Name, &device.Type, &device.Position, &device.Color)
	if err != nil {
		http.Error(writer, "Device not found", http.StatusNotFound)
		return
	}

	json.NewEncoder(writer).Encode(device)
}
