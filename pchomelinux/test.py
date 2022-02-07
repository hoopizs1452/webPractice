from selenium import webdriver
from selenium.webdriver.chrome.options import Options
from selenium.webdriver.common.by import By
import time

options = Options()
options.add_argument('--no-sandbox')
options.add_argument('--disable-dev-shm-usage')
options.add_argument('headless')

driver = webdriver.Chrome(executable_path='./chromedriver',options=options)
driver.get("https://ecvip.pchome.com.tw/login/v3/login.htm?&rurl=https://ecssl.pchome.com.tw/sys/cflow/fsindex/BigCar/BIGCAR/ItemList")
time.sleep(4)

context = driver.find_element_by_xpath("//input[@id='loginAcc']")
#login = context.get_attribute('id')
context.send_keys("hoopizs1452@gmail.com")
time.sleep(0.5)

context = driver.find_element_by_xpath("//input[@id='loginPwd']")
#login = context.get_attribute('id')
context.send_keys("wtvu12451")
time.sleep(0.5)

commit = driver.find_element_by_xpath("//a[@id='btnLogin']")
#btn = commit.get_attribute('id')
commit.click()
time.sleep(7)

statusURL = driver.current_url
#print(driver.title)
print(statusURL)
print(driver.title)
driver.close()
driver.quit()
