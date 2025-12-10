import socket
import json
import time
import uuid
import random

#UDP target
UDP_IP = "255.255.255.255"
UDP_PORT = 55010

#createUDP socket
sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
sock.setsockopt(socket.SOL_SOCKET, socket.SO_BROADCAST, 1)

# get MAC
mac_addr = ':'.join(['{:02x}'.format((uuid.getnode() >> i) & 0xff)
		for i in range(0,8*6,8)][::-1])

while True:
	value = random.choice([True,False])

	data = {
		"mac": mac_addr,
		"status": value
	}

	message = json.dumps(data).encode ('utf-8')

	sock.sendto(message, (UDP_IP, UDP_PORT))


	time.sleep(2)
