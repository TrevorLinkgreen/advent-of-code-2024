def read_lines():
    line_reader = []
    with open('input.txt', 'r') as file:
        for line in file:
            # Strip the line of whitespace and split by spaces, then convert to integers
            integers = list(map(int, line.strip().split()))
            line_reader.append(integers)
    return line_reader

# Check a line multiple ways
def check_line(original_line: []):
    # if the original one is fine, we're all fine
    if check(original_line):
        return True
    # Loop over each item in the original line
    for i in range(0, len(original_line)):
        line = original_line.copy()
        # remove one item
        line.pop(i)
        # if we're okay without that one item we're fine
        if check(line):
            return True
    # all failed
    return False


def check(line):
    line_gaps = [line[i] - line[i+1] for i in range(len(line) - 1)] # get the space between one and the other
    # It's safe it they're all positive and between 1 and 3
    # or all negative and between -1 and -3
    return (max(line_gaps) <= 3 and min(line_gaps) >= 1) or (max(line_gaps) <= -1 and min(line_gaps) >= -3)

unsafe = 0

lines = read_lines()
for line in lines:
    is_safe = check_line(line)
    print(line, is_safe)
    unsafe += 0 if is_safe else 1


print('unsafe :', unsafe)
print('safe: ', len(lines) - unsafe)
