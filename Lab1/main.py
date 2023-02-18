def reverse(num):
    a = 0
    for i in range(1, 257):
        if num * i % 256 == 1:
            a = i
            break
    return a


def encrypt():
    filename = input("Enter filename: ")
    with open(filename, 'rb+') as fh:
        content = bytearray(fh.read())
        for i, byte in enumerate(content):
            content[i] = (5 * byte + 23) % 256
        fh.seek(0)
        fh.write(content)


def decrypt():
    filename = input("Enter filename: ")
    with open(filename, 'rb+') as fh:
        content = bytearray(fh.read())
        for i, byte in enumerate(content):
            content[i] = (reverse(5) * (byte - 23)) % 256
        fh.seek(0)
        fh.write(content)


option = input("Select action:\n1. Encrypt\n2. Decrypt\nAnykey. Exit\n")

if int(option) == 1:
    encrypt()
elif int(option) == 2:
    decrypt()
else:
    exit(0)





