from pathlib import Path

# only parses the events section lmfao

filepath = Path(__file__).parent / 'beatmapEventsOsu.txt'

with open(filepath, mode = 'r', encoding = "utf-8-sig") as file:
    lines = file.readlines()

out = []

for line in lines:
    if line:
        splitLine = line.split(",")
        out.append(splitLine[2])

filepath = Path(__file__).parent / 'beatmap_clean.txt'

with open(filepath, mode = 'a', encoding ="utf-8-sig") as file:
    i = 1
    for x in out:
        if x:
            file.write(x + ",\n")
            i += 1

with open(filepath, mode = 'r', encoding = "utf-8-sig") as file:
    print(file.read())