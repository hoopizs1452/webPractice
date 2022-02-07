from selenium import webdriver
from selenium.webdriver.chrome.options import Options
from selenium.webdriver.support.wait import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.common.by import By
import time
import sys

#value = sys.argv[1:]
#acc = value[0]
#pwd = value[1]

options = Options()
options.add_argument('user-agent="Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.212 Safari/537.36"')
options.add_argument('--no-sandbox')
options.add_argument('--disable-dev-shm-usage')
options.add_argument('--headless')
options.add_argument('window-size=1920x3000')
options.add_argument('--disable-gpu')
options.add_argument('--hide-scrollbars')
options.add_argument('blink-settings=imagesEnabled=false')
options.add_experimental_option('excludeSwitches', ['enable-automation'])

driver = webdriver.Chrome(executable_path='/var/www/html/pchomelinux/chromedriver',options=options)
#driver.get("https://shopping.pchome.com.tw/")

driver.get("https://ecvip.pchome.com.tw/login/v3/login.htm?&rurl=https://ecssl.pchome.com.tw/sys/cflow/fsindex/BigCar/BIGCAR/ItemList")
time.sleep(4)

context = driver.find_element_by_css_selector('#loginAcc') #PChome
context.send_keys("hoopizs1452@gmail.com") #"hoopizs1452@gmail.com" #PChome
time.sleep(0.5)

context = driver.find_element_by_css_selector('#loginPwd') #PChome
context.send_keys("wtvu1245") #"wtvu1245" #PChome
time.sleep(0.5)

commit = driver.find_element_by_css_selector('#btnLogin')
commit.click()
time.sleep(5)

statusURL = driver.current_url
title = driver.title
title.replace(" ", "")
print(title)
#print(statusURL)
#print(driver.page_source)
driver.close()
