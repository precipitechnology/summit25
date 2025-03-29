# If/Else

$number = 10

if ($number -gt 10) {
    Write-Output "Greater than 10"
} elseif ($number -eq 10) {
    Write-Output "Exactly 10"
} else {
    Write-Output "Less than 10"
}

#Switch
$color = "blue"

switch ($color) {
    "red"   { "You picked red." }
    "blue"  { "You picked blue." }
    "green" { "You picked green." }
    default { "Unknown color." }
}

#For
for ($i = 0; $i -lt 5; $i++) {
    Write-Output "Index: $i"
}

#ForEach
$items = 1..5
foreach ($item in $items) {
    Write-Output "Item: $item"
}

#While
$i = 0
while ($i -lt 3) {
    Write-Output "While Count: $i"
    $i++
}

#DoWhile
$i = 0
do {
    Write-Output "Do Count: $i"
    $i++
} while ($i -lt 3)

#Break
foreach ($i in 1..5) {
    if ($i -eq 3) { continue }
    if ($i -eq 5) { break }
    Write-Output "Looping $i"
}