#!/bin/sh



midish -b <<end

import "$1"      #midi input file
#print[tlist]
sel 10000
#for trk in {"a" "b" "c"}{
for trk in [tlist]{
print \$trk; 
ct \$trk;
ttransp $2;
}
export "out_$2_$1"
exit
end





