def generate_random_sequence(a, c, m, x0):
    x = x0
    while True:
        x = (a * x + c) % m
        yield x

def find_period_length(a, c, m, x0):
    sequence = generate_random_sequence(a, c, m, x0)
    x = next(sequence)
    period_start = x
    period_length = 1
    while x != period_start or period_length == 1:
        x = next(sequence)
        period_length += 1
    return period_length * m.bit_length()  # in bits

def count_even_odd_bytes(a, c, m, x0):
    sequence = generate_random_sequence(a, c, m, x0)
    x = next(sequence)
    period_start = x
    period_length = 1
    even_count = 0
    odd_count = 0
    while x != period_start or period_length == 1:
        x = next(sequence)
        period_length += 1
        byte = x.to_bytes(1, byteorder='big')
        if byte[0] % 2 == 0:
            even_count += 1
        else:
            odd_count += 1
    return even_count, odd_count

def count_zeros_ones_bits(a, c, m, x0):
    sequence = generate_random_sequence(a, c, m, x0)
    x = next(sequence)
    period_start = x
    period_length = 1
    zeros_count = 0
    ones_count = 0
    while x != period_start or period_length == 1:
        x = next(sequence)
        period_length += 1
        bits = bin(x)[2:].zfill(m.bit_length())
        for bit in bits:
            if bit == '0':
                zeros_count += 1
            else:
                ones_count += 1
    return zeros_count, ones_count

a = 89
c = 87
m = 193
x0 = 17

print(f"Period length in bits: {find_period_length(a, c, m, x0)}")
even_count, odd_count = count_even_odd_bytes(a, c, m, x0)
print(f"Even bytes count: {even_count},\n odd bytes count: {odd_count}")
zeros_count, ones_count = count_zeros_ones_bits(a, c, m, x0)
print(f"Zeros bits count: {zeros_count},\n ones bits count: {ones_count}")
