import requests
from device_helper import get_or_create_device_id

BASE_URL = "http://localhost:5000/api"

class ApiClient:
    def __init__(self):
        self.device_id = get_or_create_device_id()
        self.headers = {
            "X-Device-Id": self.device_id,
            "Content-Type": "application/json"
        }

    def create_reminder(self, dto: dict) -> int:
        response = requests.post(
            f"{BASE_URL}/reminders",
            json=dto,
            headers=self.headers
        )
        response.raise_for_status()
        return response.json()["id"]

    def get_reminders(self, user_id: int) -> list:
        response = requests.get(
            f"{BASE_URL}/reminders/{user_id}",
            headers=self.headers
        )
        response.raise_for_status()
        return response.json()