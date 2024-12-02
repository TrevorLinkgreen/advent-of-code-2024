def read_lines():
    line_reader = []
    with open('input.txt', 'r') as file:
        for line in file:
            # Strip the line of whitespace and split by spaces, then convert to integers
            integers = list(map(int, line.strip().split()))
            line_reader.append(integers)
    return line_reader

def check(line):
    line_gaps = [line[i] - line[i+1] for i in range(len(line) - 1)] # get the space between one and the other
    # It's safe it they're all positive and between 1 and 3
    # or all negative and between -1 and -3
    return (max(line_gaps) <= 3 and min(line_gaps) >= 1) or (max(line_gaps) <= -1 and min(line_gaps) >= -3)

unsafe = 0

lines = read_lines()
for line in lines:
    is_safe = check(line)
    unsafe += 0 if is_safe else 1


print('unsafe :', unsafe)
print('safe: ', len(lines) - unsafe)
