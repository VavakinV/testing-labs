import pyautogui

# 1. Размеры экрана
screenWidth, screenHeight = pyautogui.size() # Returns two integers, the width and height of the screen. (The primary monitor, in multi-monitor setups.)
print(f"Ширина, высота экрана: ({screenWidth}, {screenHeight})")
currentMouseX, currentMouseY = pyautogui.position() # Returns two integers, the x and y of the mouse cursor's current position.
print(f"Текущая позиция курсора: ({currentMouseX}, {currentMouseY})")

# 2. Перемещение и клик мыши
# pyautogui.moveTo(500, 450) # Move the mouse to the x, y coordinates 100, 150.
# pyautogui.click() # Click the mouse at its current location.
# pyautogui.click(200, 220) # Click the mouse at the x, y coordinates 200, 220.

# 3. Плавное перемещение
# pyautogui.moveTo(700, 700, duration=2, tween=pyautogui.easeInOutQuad) # Use tweening/easing function to move mouse over 2 seconds.

# 4. Печать с клавиатуры с интервалом
# pyautogui.write('Hello world!', interval=0.25)  # Type with quarter-second pause in between each key.

# 5. Нажатие, зажатие кнопки
# pyautogui.press('esc') # Simulate pressing the Escape key.
# pyautogui.keyDown('shift')
# pyautogui.write(['left', 'left', 'left', 'left', 'left', 'left'])
# pyautogui.keyUp('shift')

# 6. Ввод комбинации клавиш
# pyautogui.hotkey('ctrl', 'c')

# 7. Создание скриншота
# im1 = pyautogui.screenshot()
# im1.save('Lab5/my_screenshot.png')

# 8. Поиск изображения на экране
buttonx, buttony = pyautogui.locateCenterOnScreen('Lab5/button.png', confidence=0.9)

print(f"Центр изображения: ({buttonx}, {buttony})")
pyautogui.moveTo(buttonx, buttony, duration=0.5)
pyautogui.click()

