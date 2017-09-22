const _ = require('lodash')
const data = require('./data')

function split(cuts, chunk, value) {
    const eligibleCuts = cuts.filter(cut => chunk >= cut.size)

    return eligibleCuts.length ?
        _.max(eligibleCuts.map(cut => split(eligibleCuts, chunk - cut.size, value + cut.value)))
        : value - chunk
}

const answer = _.sum(_.values(data).map(jewel => _.sum(jewel.rawChunks.map(r => split(jewel.cuts, r, 0)))))

console.log(answer)
