characteristic_function = [1, 1, 0, 0, 0, 0, 1, 1, 1]
register_size = 8
register_value = 0b10000000

def shift_right(value):
    new_bit = sum([get_bit(value, n) * characteristic_function[n] for n in range(len(characteristic_function))]) % 2
    return (value >> 1) | (new_bit << (register_size - 1))

def get_bit(value, position):
    return (value >> position) & 1

sequence = []
period = 0
while True:
    sequence.append(register_value % 256)
    register_value = shift_right(register_value)
    period += 1
    if register_value == 0b10000000:
        break

even_count = sum([1 for value in sequence if value % 2 == 0])
odd_count = sum([1 for value in sequence if value % 2 == 1])

binary_sequence = [bin(value)[2:].zfill(8) for value in sequence]
zero_count = sum([binary_value.count('0') for binary_value in binary_sequence])
one_count = sum([binary_value.count('1') for binary_value in binary_sequence])

print('Characteristic function:', characteristic_function)
print('Register size:', register_size)
print('Initial register value:', bin(register_value)[2:].zfill(8))
print('Generated sequence:', sequence)
print('Period length:', period)
print('Number of even numbers:', even_count)
print('Number of odd numbers:', odd_count)
print('Number of zeros:', zero_count)
print('Number of ones:', one_count)
