import pyautogui
import time
import random
import string

pyautogui.FAILSAFE = True

# ----------------- УТИЛИТЫ -----------------

def rand_string(n=8):
    return ''.join(random.choices(string.ascii_letters + string.digits, k=n))

def wait_and_click(image, confidence=0.8, timeout=20):
    start = time.time()
    while time.time() - start < timeout:
        loc = pyautogui.locateOnScreen(image, confidence=confidence)
        if loc:
            center = pyautogui.center(loc)
            pyautogui.moveTo(center, duration=0.3)
            pyautogui.click()
            return True
        time.sleep(0.5)
    print(f"Не найдено: {image}")
    return False

def find_and_offset_click(image, dx=0, dy=0, confidence=0.8, timeout=20):
    start = time.time()
    while time.time() - start < timeout:
        loc = pyautogui.locateOnScreen(image, confidence=confidence)
        if loc:
            center = pyautogui.center(loc)
            pyautogui.moveTo(center.x + dx, center.y + dy, duration=0.3)
            pyautogui.click()
            return True
        time.sleep(0.5)
    print(f"Не найдено: {image}")
    return False

def type_with_clear(text):
    pyautogui.hotkey('ctrl', 'a')
    pyautogui.press('backspace')
    pyautogui.write(text, interval=0.05)


# ----------------- СТАРТ -----------------

print("Старт через 5 секунд...")
time.sleep(5)


# 1. specialties.png
wait_and_click("specialties.png")

# 2. create.png
wait_and_click("create.png")

# ----------------- 4 раза ФИИТ -----------------

for _ in range(4):
    find_and_offset_click("specname.png", dx=80)
    pyautogui.write(rand_string())

    find_and_offset_click("speccode.png", dx=80)
    pyautogui.write("ФИИТ")

    find_and_offset_click("specdesc.png", dx=80)
    pyautogui.write(rand_string())

    wait_and_click("ok.png")
    wait_and_click("create.png")


# ----------------- 3 раза ПМ -----------------

for _ in range(3):
    find_and_offset_click("specname.png", dx=80)
    pyautogui.write(rand_string())

    find_and_offset_click("speccode.png", dx=80)
    pyautogui.write("ПМ")

    find_and_offset_click("specdesc.png", dx=80)
    pyautogui.write(rand_string())

    wait_and_click("ok.png")
    wait_and_click("create.png")


# ----------------- 3 раза ПМИ -----------------

for _ in range(3):
    find_and_offset_click("specname.png", dx=80)
    pyautogui.write(rand_string())

    find_and_offset_click("speccode.png", dx=80)
    pyautogui.write("ПМИ")

    find_and_offset_click("specdesc.png", dx=80)
    pyautogui.write(rand_string())

    wait_and_click("ok.png")
    wait_and_click("create.png")


# ----------------- UPDATE (пока есть PICode или PMICode) -----------------

while True:
    pi = pyautogui.locateOnScreen("PICode.png", confidence=0.8)
    pmi = pyautogui.locateOnScreen("PMICode.png", confidence=0.8)

    target = pi or pmi

    if not target:
        break

    x, y = pyautogui.center(target)
    pyautogui.moveTo(x - 300, y, duration=0.3)
    pyautogui.click()

    wait_and_click("update.png")
    wait_and_click("speccode.png")

    find_and_offset_click("specname.png", dx=80)
    type_with_clear("ФКТиПМ")

    wait_and_click("ok.png")

# ----------------- DELETE -----------------

loc = pyautogui.locateOnScreen("FIIT.png", confidence=0.8)
if loc:
    x, y = pyautogui.center(loc)
    pyautogui.moveTo(x - 300, y, duration=0.3)
    pyautogui.click()
    wait_and_click("delete.png")


# ----------------- CLOSE + SETS -----------------

wait_and_click("close.png")
wait_and_click("sets.png")

print("АВТОТЕСТ ЗАВЕРШЁН")
