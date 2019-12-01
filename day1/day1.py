def module_fuel_requirement(mass):
    return (int)(mass / 3) - 2

def total_fuel_requirements():
    weights = open("module_weights.txt", "r").readlines()
    total = 0
    for w in weights:
        total += module_fuel_requirement(int(w))

    return total

def actual_total_fuel():
    weights = open("module_weights.txt", "r").readlines()
    total = 0
    for w in weights:
        module_requirements = module_fuel_requirement(int(w))
        additional = module_fuel_requirement(module_requirements)
        while additional > 0:
            module_requirements += additional
            additional = module_fuel_requirement(additional)
        total += module_requirements

    return total
