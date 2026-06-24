import os
import uuid

def get_or_create_device_id() -> str:
    path = os.path.join(
        os.getenv("APPDATA"),  # C:\Users\Mohamed\AppData\Roaming
        "ReminderX",
        "device.txt"
    )

    os.makedirs(os.path.dirname(path), exist_ok=True)

    if not os.path.exists(path):
        with open(path, "w") as f:
            f.write(str(uuid.uuid4()))

    with open(path, "r") as f:
        return f.read().strip()