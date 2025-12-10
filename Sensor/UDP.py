import requests
import time
import socket
import json

UDP_IP = "0.0.0.0"
UDP_PORT = 55010

sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
sock.bind((UDP_IP, UDP_PORT))

print(f"Listening for UDP packets on {UDP_IP}:{UDP_PORT}")
 
API_URL = "https://zealand3.rasekh.dk/api/Shelf"
SEND_INTERVAL = 2


def send_data():
    data, addr = sock.recvfrom(1024)
    js = json.loads(data.decode())
    ma = js["mac"]
    sta = js["status"]
    data = {
        "mac": ma,
        "status":sta
    }
    print(f"------------data is filled with mac :{ma}  and status:{sta}")
    headers = {
        "Content-Type": "application/json",
        "User-Agent": "Mozilla/5.0"
    }

    try:
        response = requests.post(API_URL, headers=headers, json=data, timeout=5)
        if response.ok:
            print(f"Data sent successfully. Status: {response.status_code}")
        else:
            print(f"Failed to send data. Status: {response.status_code}, Response: {response.text}")
    except requests.exceptions.RequestException as e:
        print(f"Error sending data: {e}")

def main():
    while True:
        send_data()
        time.sleep(SEND_INTERVAL)

if __name__ == "__main__":
    main()
